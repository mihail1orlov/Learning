namespace MinimalApiDemo;

public static class Api
{
    public static void ConfigureApi(this WebApplication application)
    {
        // All of my Api mapping
        application.MapGet("/Users", GetUsers);
        application.MapGet("/Users/{id}", GetUser);
        application.MapPost("/Users", InsertUser);
        application.MapPut("/Users", UpdateUser);
        application.MapDelete("/Users", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserData userData) =>
        await GetResult(async () => Results.Ok(await userData.GetUsers()));

    private static async Task<IResult> GetUser(int id, IUserData data)
        => await GetResult(async () =>
        {
            var userModel = await data.GetUser(id);
            return userModel == null ? Results.NotFound() : Results.Ok(userModel);
        });

    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
        => await GetResult(async () =>
        {
            await data.InsertUser(user);
            return Results.Ok();
        });

    private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
        => await GetResult(async () =>
        {
            await data.UpdateUser(user);
            return Results.Ok();
        });

    private static async Task<IResult> DeleteUser(int id, IUserData data)
        => await GetResult(async () =>
        {
            await data.DeleteUser(id);
            return Results.Ok();
        });

    private static async Task<IResult> GetResult(Func<Task<IResult>> func)
    {
        IResult result;

        try
        {
            result = await func.Invoke();
        }
        catch (Exception e)
        {
            result = Results.Problem(e.Message);
        }

        return result;
    }
}