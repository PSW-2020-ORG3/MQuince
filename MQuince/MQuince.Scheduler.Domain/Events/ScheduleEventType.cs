namespace MQuince.Scheduler.Domain.Events
{
    public enum ScheduleEventType
    {
        JOIN,
        CREATED,
        EXIT,
        FROMSPECTODOCTOR,
        FROMDOCTORTOSPEC,
        FROMDOCTORTODATEPICKER,
        FROMDATEPICKERTODOCTOR,
        FROMDATEPICKERTOPERIOD,
        FROMPERIODTODATEPICKER
    }
}
