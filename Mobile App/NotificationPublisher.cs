using System;
using Android.App;
using Android.Content;
using Android.Media;

namespace MedicalApp
{
    /* This class receives the alarm broadcast when a medication alarm is triggered.
    It builds and publishes the Android notification reminding the user to take 
    their medication
    */

    [BroadcastReceiver]
    public class NotificationPublisher: BroadcastReceiver
    {
        /* ovveride void OnRecieve(Context context, Intent intent)
         * This method is called by Android when it first receives the alarm broadcast.
         * It retrieves medication info from the alarm Intent and publishes the notification
         * param: Context context - The context from which the broadcast was made from
         * param: Intent intent - The intent that trigged the broadcast
        */
        public override void OnReceive(Context context, Intent intent)
        {
            Notification notif = buildNotification(context, intent.GetStringExtra("MedicationName"),
                intent.GetStringExtra("Time"), intent.GetStringExtra("Dosage"));

            NotificationManager notifMngr = context.GetSystemService(Context.NotificationService)
                as NotificationManager;

            notifMngr.Notify(0, notif);
        }

        /* Notification buildNotification(Context context, string medName, string time, string dosage)
         * This method takes in the medication details to be displayed on the Notification 
         * and builds it accordingly.
         * param: Context context - the context where to build the notification
         * param: string medName - Medication name to be displayed on notification
         * param: string time - Medication time to be displayed on notification
         * param: string dosage - Medication dosage to be displayed on notification
         * return: Notification - The built notificaiton
        */
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