using System.Collections;
using System.Linq;
using DevExpress.Web.Mvc;
using DevExpressMvcSchedulerEF.Views;

namespace DevExpressMvcSchedulerEF
{
    public class SchedulerDataObject
    {
        public IEnumerable Appointments { get; set; }
        public IEnumerable Resources { get; set; }
    }

    public class SchedulerDataHelper
    {
        public static IEnumerable GetResources()
        {
            return SchedulerSettingsHelper.LocalContext.EFResources.Local;
        }
        public static IEnumerable GetAppointments()
        {
            return SchedulerSettingsHelper.LocalContext.EFAppointments.Local;
        }
        public static SchedulerDataObject DataObject
        {
            get
            {
                return new SchedulerDataObject()
                {
                    Appointments = GetAppointments(),
                    Resources = GetResources()
                };
            }
        }

        static MVCxAppointmentStorage defaultAppointmentStorage;
        public static MVCxAppointmentStorage DefaultAppointmentStorage
        {
            get
            {
                if (defaultAppointmentStorage == null)
                    defaultAppointmentStorage = CreateDefaultAppointmentStorage();
                return defaultAppointmentStorage;
            }
        }

        static MVCxAppointmentStorage CreateDefaultAppointmentStorage()
        {
            MVCxAppointmentStorage appointmentStorage = new MVCxAppointmentStorage();
            appointmentStorage.Mappings.AppointmentId = "UniqueID";
            appointmentStorage.Mappings.Start = "StartDate";
            appointmentStorage.Mappings.End = "EndDate";
            appointmentStorage.Mappings.Subject = "Subject";
            appointmentStorage.Mappings.Description = "Description";
            appointmentStorage.Mappings.Location = "Location";
            appointmentStorage.Mappings.AllDay = "AllDay";
            appointmentStorage.Mappings.Type = "Type";
            appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo";
            appointmentStorage.Mappings.ReminderInfo = "ReminderInfo";
            appointmentStorage.Mappings.Label = "Label";
            appointmentStorage.Mappings.Status = "Status";
            appointmentStorage.Mappings.ResourceId = "ResourceIDs";
            return appointmentStorage;
        }

        static MVCxResourceStorage defaultResourceStorage;
        public static MVCxResourceStorage DefaultResourceStorage
        {
            get
            {
                if (defaultResourceStorage == null)
                    defaultResourceStorage = CreateDefaultResourceStorage();
                return defaultResourceStorage;
            }
        }
        static MVCxResourceStorage CreateDefaultResourceStorage()
        {
            MVCxResourceStorage resourceStorage = new MVCxResourceStorage();
            resourceStorage.Mappings.ResourceId = "ResourceID";
            resourceStorage.Mappings.Caption = "ResourceName";
            resourceStorage.Mappings.Color = "Color";
            return resourceStorage;
        }

        public static void InsertAppointment(EFAppointment appt)
        {
            if (appt == null)
                return;
            SchedulerContext db = SchedulerSettingsHelper.LocalContext;
            db.EFAppointments.Local.Add(appt);
            db.SaveChanges();
        }
        public static void UpdateAppointment(EFAppointment appt)
        {
            if (appt == null)
                return;
            SchedulerContext db = SchedulerSettingsHelper.LocalContext;
            EFAppointment query = (EFAppointment)(from carSchedule in db.EFAppointments.Local where carSchedule.UniqueID == appt.UniqueID select carSchedule).SingleOrDefault();

            query.UniqueID = appt.UniqueID;
            query.StartDate = appt.StartDate;
            query.EndDate = appt.EndDate;
            query.AllDay = appt.AllDay;
            query.Subject = appt.Subject;
            query.Description = appt.Description;
            query.Location = appt.Location;
            query.RecurrenceInfo = appt.RecurrenceInfo;
            query.ReminderInfo = appt.ReminderInfo;
            query.Status = appt.Status;
            query.Type = appt.Type;
            query.Label = appt.Label;
            query.ResourceIDs = appt.ResourceIDs;
            db.SaveChanges();
        }
        public static void RemoveAppointment(EFAppointment appt)
        {
            if (appt == null)
                return;
            SchedulerContext db = SchedulerSettingsHelper.LocalContext;
            EFAppointment query = (EFAppointment)(from carSchedule in db.EFAppointments.Local where carSchedule.UniqueID == appt.UniqueID select carSchedule).SingleOrDefault();
            db.EFAppointments.Remove(query);
            db.SaveChanges();
        }
    }
}