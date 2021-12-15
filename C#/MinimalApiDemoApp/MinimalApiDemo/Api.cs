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

    private static async Task<IResult> GetUsers(IUserData userData)
    {
        IResult result;

        try
        {
            result = Results.Ok(await userData.GetUsers());
        }
        catch (Exception e)
        {
            result = Results.Problem(e.Message);
        }

        return result;
    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        IResult result;

        try
        {
            var userModel = await data.GetUser(id);
            result = userModel == null ? Results.NotFound() : Results.Ok(userModel);
        }
        catch (Exception e)
        {
            result = Results.Problem(e.Message);
        }

        return result;
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    {
        IResult result;

        try
        {
            await data.InsertUser(user);
            result = Results.Ok();
        }
        catch (Exception e)
        {
            result = Results.Problem(e.Message);
        }

        return result;
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
    {
        IResult result;

        try
        {
            await data.UpdateUser(user);
            result = Results.Ok();
        }
        catch (Exception e)
        {
            result = Results.Problem(e.Message);
        }

        return result;
    }

    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        IResult result;

        try
        {
            await data.DeleteUser(id);
            result = Results.Ok();
        }
        catch (Exception e)
        {
            result = Results.Problem(e.Message);
        }

        return result;
    }
}