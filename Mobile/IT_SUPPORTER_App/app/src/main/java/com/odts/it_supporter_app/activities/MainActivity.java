package com.odts.it_supporter_app.activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TextView;

import com.google.firebase.messaging.FirebaseMessaging;
import com.odts.it_supporter_app.R;

public class MainActivity extends AppCompatActivity {

    static   String strSDesc = "ShortDesc";
    static String strIncidentNo = "IncidentNo";
    static String strDesc="IncidentNo";
    static String topic="1";
    Integer itSupporterId = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        SharedPreferences share = getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        TextView tx = findViewById(R.id.testID);
        itSupporterId = share.getInt("itSupporterId", 0);

        tx.setText(itSupporterId.toString());

        onNewIntent(getIntent());
        FirebaseMessaging.getInstance().subscribeToTopic(itSupporterId.toString());
    }

    @Override
    public void onNewIntent(Intent intent) {
        Bundle extras = intent.getExtras();
        if (extras != null) {
            setContentView(R.layout.activity_main);
            final TextView IncidentTextView = (TextView) findViewById(R.id.txtIncidentNo);
            final TextView SDescTextView = (TextView) findViewById(R.id.txtShortDesc);

            final TextView DescTextView = (TextView) findViewById(R.id.txtDesc);
            strSDesc = extras.getString("ShortDesc","ShortDesc");
            strIncidentNo = extras.getString("IncidentNo", "IncidentNo");
            strDesc=extras.getString("Description","IncidentNo");

            IncidentTextView.setText(strIncidentNo);
            SDescTextView.setText(strSDesc);
            DescTextView.setText(strDesc);
        }
    }
}
