using System;
using Android.App;
using Android.Content;
using Android.Media;

namespace MedicalApp
{
    [BroadcastReceiver]
    public class NotificationPublisher: BroadcastReceiver
    {

        public override void OnReceive(Context context, Intent intent)
        {
            Notification notif = buildNotification(context, intent.GetStringExtra("MedicationName"),
                intent.GetStringExtra("Time"), intent.GetStringExtra("Dosage"));

            NotificationManager notifMngr = context.GetSystemService(Context.NotificationService)
                as NotificationManager;

            notifMngr.Notify(0, notif);
        }

        public Notification buildNotification(Context context, string medName, string time, string dosage)
        {
            Notification.Builder builder = new Notification.Builder(context)
                   .SetContentTitle("Medication Needs To Be Taken")
                   .SetContentText($"{medName}  {dosage}  {time}")
                   .SetSmallIcon(Resource.Drawable.Icon)
                   .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm));

            return builder.Build();
        }

       
    }
}