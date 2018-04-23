using DevExpress.Web.Mvc;
using DevExpress.Web.ASPxScheduler;
using System;
using DevExpress.XtraScheduler;
using DevExpressMvcSchedulerEF.Views;
using System.Data.Entity;
using DevExpressMvcSchedulerEF;

    #region #schedulersettingshelper
    public class SchedulerSettingsHelper
    {

        static SchedulerContext _localcontext;
        public static SchedulerContext LocalContext
        {
            get
            {
                if (_localcontext == null)
                    _localcontext = new SchedulerContext();
                return _localcontext;
            }
        }

        static SchedulerSettings _commonSchedulerSettings;
        public static SchedulerSettings CommonSchedulerSettings
        {
            get
            {
                if (_commonSchedulerSettings == null)
                    _commonSchedulerSettings = CreateSchedulerSettings();
                return _commonSchedulerSettings;
            }
        }
        static SchedulerSettings CreateSchedulerSettings()
        {
            Database.SetInitializer(new SchedulerContextSeedInilializer());
            LocalContext.Database.Initialize(true);


            LocalContext.EFAppointments.Load();
            LocalContext.EFResources.Load();
            
            
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "scheduler";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "SchedulerPartial" };
            settings.EditAppointmentRouteValues = new { Controller = "Home", Action = "EditAppointment" };

            settings.Storage.Appointments.Assign(SchedulerDataHelper.DefaultAppointmentStorage);
            settings.Storage.Resources.Assign(SchedulerDataHelper.DefaultResourceStorage);

            settings.Storage.Appointments.ResourceSharing = true;
            settings.Storage.Resources.ColorSaving = ColorSavingType.ArgbColor;
            settings.GroupType = SchedulerGroupType.Resource;

            settings.Width = 300;
            settings.Views.WeekView.Styles.DateCellBody.Height = 50;
            settings.Views.MonthView.CellAutoHeightOptions.Mode = AutoHeightMode.FitToContent;
            settings.Views.MonthView.AppointmentDisplayOptions.AppointmentAutoHeight = true;
            settings.Views.MonthView.AppointmentDisplayOptions.TimeDisplayType = AppointmentTimeDisplayType.Clock;
            settings.Views.DayView.Styles.ScrollAreaHeight = 250;
            settings.Views.DayView.ShowWorkTimeOnly = true;
            settings.Views.DayView.DayCount = 2;
            settings.Start = new DateTime(2012, 5, 9);
            settings.ActiveViewType = SchedulerViewType.Day;

            return settings;
        }
    }

#endregion #schedulersettingshelper