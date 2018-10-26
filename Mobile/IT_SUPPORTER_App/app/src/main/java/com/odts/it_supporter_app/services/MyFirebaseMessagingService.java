package com.odts.it_supporter_app.services;

import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.graphics.BitmapFactory;
import android.media.RingtoneManager;
import android.net.Uri;
import android.support.v4.app.NotificationCompat;
import android.util.Log;

import com.google.firebase.messaging.RemoteMessage;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.activities.MainActivity;

public class MyFirebaseMessagingService extends  com.google.firebase.messaging.FirebaseMessagingService {
    private static final String TAG="FirebaseMessagingServic";

    public MyFirebaseMessagingService() {
    }

    @Override
    public void onMessageReceived(RemoteMessage remoteMessage) {

        String strTitle=remoteMessage.getData().get("title");
        String message=remoteMessage.getNotification().getBody();
        Log.d(TAG,"onMessageReceived: Message Received: \n" +
                "Title: " + strTitle + "\n" +
                "Message: "+ message);

        sendNotification(strTitle,message);
    }

    @Override
    public void onDeletedMessages() {

    }

    private  void sendNotification(String title,String messageBody) {
        Intent[] intents= new Intent[1];
        Intent intent= new Intent(this,MainActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        intent.putExtra("IncidentNo", title);
        intent.putExtra("ShortDesc", messageBody);
        intent.putExtra("Description",messageBody);
        intents[0]=intent;
        PendingIntent pendingIntent=PendingIntent.getActivities(this,0, intents,PendingIntent.FLAG_ONE_SHOT);
        Uri defaultSoundUri= RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
        NotificationCompat.Builder notificationbuilder = new NotificationCompat.Builder(this)
                .setSmallIcon(R.drawable.ic_launcher_foreground)
                .setContentTitle("Service Now")
                .setContentText(messageBody)
                .setAutoCancel(true)
                .setSound(defaultSoundUri)
                .setContentIntent(pendingIntent)
                .setLargeIcon(BitmapFactory.decodeResource
                        (getResources(), R.mipmap.ic_launcher));;

        NotificationManager notificationManager=(NotificationManager)
                getSystemService(Context.NOTIFICATION_SERVICE);
        notificationManager.notify(0, notificationbuilder.build());
    }
}
