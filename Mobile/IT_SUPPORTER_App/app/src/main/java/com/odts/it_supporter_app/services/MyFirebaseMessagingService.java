package com.odts.it_supporter_app.services;

import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.BitmapFactory;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Build;
import android.support.v4.app.NotificationCompat;
import android.support.v4.app.NotificationManagerCompat;
import android.util.Log;

import com.google.firebase.messaging.RemoteMessage;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.activities.LoginActivity;
import com.odts.it_supporter_app.activities.MainActivity;

public class MyFirebaseMessagingService extends  com.google.firebase.messaging.FirebaseMessagingService {
    private static final String TAG="FirebaseMessagingServic";
    SharedPreferences share;
    public MyFirebaseMessagingService() {
    }

    @Override
    public void onMessageReceived(RemoteMessage remoteMessage) {

//        String strTitle=remoteMessage.getData().get("AgencyName");
//
//        String message=remoteMessage.getNotification().getBody();
//        Log.e(TAG,"onMessageReceived: Message Received: \n" +
//                "Title: " + strTitle + "\n" +
//                "Message: "+ message);
//        String channelId = "Default";
//        Notification notification = new NotificationCompat.Builder(this, channelId)
//                .setContentTitle(remoteMessage.getNotification().getTitle())
//                .setContentText(remoteMessage.getNotification().getBody())
//                .setSmallIcon(R.mipmap.ic_launcher)
//                .build();
//        NotificationManagerCompat manager = NotificationManagerCompat.from(getApplicationContext());
//        manager.notify(123, notification);


        Intent intent = new Intent(this, LoginActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        PendingIntent pendingIntent = PendingIntent.getActivity(this, 0, intent, PendingIntent.FLAG_ONE_SHOT);
        String channelId = "Default";
        NotificationCompat.Builder builder = new  NotificationCompat.Builder(this, channelId)
                .setSmallIcon(R.mipmap.ic_launcher)
                .setContentTitle(remoteMessage.getNotification().getTitle())
                .setContentText(remoteMessage.getNotification().getBody()).setAutoCancel(true).setContentIntent(pendingIntent)
                .setSound(RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION));
        NotificationManager manager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            NotificationChannel channel = new NotificationChannel(channelId, "Default channel", NotificationManager.IMPORTANCE_DEFAULT);
            manager.createNotificationChannel(channel);
        }

        manager.notify(0, builder.build());
        share = getSharedPreferences("firebaseData", MODE_PRIVATE);
        SharedPreferences.Editor editor = share.edit();
        editor.putString("AgencyName",remoteMessage.getData().get("AgencyName"));
        editor.putString("AgencyAddress",remoteMessage.getData().get("AgencyAddress"));
        editor.putString("TicketsInfo",remoteMessage.getData().get("TicketsInfo"));
        editor.putString("RequestName",remoteMessage.getData().get("RequestName"));
        editor.putString("RequestId",remoteMessage.getData().get("RequestId"));
        editor.putString("Date", remoteMessage.getData().get("DateSend"));
        editor.commit();
        Intent launchIntent = getPackageManager().getLaunchIntentForPackage(getPackageName());
        launchIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(launchIntent);



        //sendNotification(strTitle,message);
    }

    @Override
    public void onDeletedMessages() {

    }

//    private  void sendNotification(String title,String messageBody) {
//        Intent[] intents= new Intent[1];
//        Intent intent= new Intent(this,MainActivity.class);
//        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
//        intent.putExtra("IncidentNo", title);
//        intent.putExtra("ShortDesc", messageBody);
//        intent.putExtra("Description",messageBody);
//        intents[0]=intent;
//        PendingIntent pendingIntent=PendingIntent.getActivities(this,0, intents,PendingIntent.FLAG_ONE_SHOT);
//        Uri defaultSoundUri= RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
//        NotificationCompat.Builder notificationbuilder = new NotificationCompat.Builder(this)
//                .setSmallIcon(R.drawable.ic_launcher_foreground)
//                .setContentTitle("Service Now")
//                .setContentText(messageBody)
//                .setAutoCancel(true)
//                .setSound(defaultSoundUri)
//                .setContentIntent(pendingIntent)
//                .setLargeIcon(BitmapFactory.decodeResource
//                        (getResources(), R.mipmap.ic_launcher));;
//
//        NotificationManager notificationManager=(NotificationManager)
//                getSystemService(Context.NOTIFICATION_SERVICE);
//        notificationManager.notify(0, notificationbuilder.build());
//    }
}
