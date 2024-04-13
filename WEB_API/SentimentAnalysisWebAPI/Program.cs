
using Microsoft.ML.Data;
using Microsoft.Extensions.ML;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPredictionEnginePool<ModelInput, ModelOutput>()
    .FromFile(modelName: "ClassificationModel", filePath: "D:\\INFT3000\\BlazorApps\\SentimentAnalysisWebAPI\\SentimentAnalysisWebAPI\\ClassificationModel\\ClassificationModel.mlnet", watchForChanges: true);

var app = builder.Build();

var predictionHandler =
    async (PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool, ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(modelName: "ClassificationModel", input));

app.MapPost("/predict", predictionHandler);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class ModelInput
{
    [LoadColumn(0)]
    [ColumnName(@"Text")]
    public string Text { get; set; }

    [LoadColumn(1)]
    [ColumnName(@"Label")]
    public float Label; 
}

public class ModelOutput
{

    [ColumnName(@"Label")]
    public uint Label { get; set; }

    [ColumnName(@"PredictedLabel")]
    public float PredictedLabel { get; set; }

    [ColumnName(@"Score")]
    public float[] Score { get; set; }
}

