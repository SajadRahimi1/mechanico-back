using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace mechanico.Context;

public class ResultData:IActionResult
{
    private Data data;

    public ResultData(Data data)
    {
        this.data = data;
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var returnData = new ObjectResult(data) { StatusCode = data.statusCodes };
        await returnData.ExecuteResultAsync(context);
    }
}

public class Data
{
    public int statusCodes { get; set; } = StatusCodes.Status200OK;

    public object? data { get; set; }

    public string? Token { get; set; }
}