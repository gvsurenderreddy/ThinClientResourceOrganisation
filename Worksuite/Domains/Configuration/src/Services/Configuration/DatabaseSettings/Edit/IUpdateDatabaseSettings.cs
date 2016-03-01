namespace WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit
{
    public interface IUpdateDatabaseSettings
    {

        UpdateDatabaseSettingsResponse execute(UpdateDatabaseSettingRequest updateDatabaseSettingRequest);
    }
}