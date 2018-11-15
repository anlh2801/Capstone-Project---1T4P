package com.odts.it_supporter_app.activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import com.firebase.client.Firebase;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.text.DateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

public class StatusTimelineActivity extends AppCompatActivity {
    Button btnAccept, bt2, bt3, bt4, bt5;
    Firebase reference1;
    ITSupporterService itSupporterService;
    SharedPreferences sharedPreferences;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        itSupporterService = new ITSupporterService();
        setContentView(R.layout.activity_status_timeline);
        Firebase.setAndroidContext(this);
        Intent myIntent = getIntent();
        int requestIDTime = myIntent.getIntExtra("requestIDTime", 0);
        sharedPreferences = getSharedPreferences("ODTS", MODE_PRIVATE);
        final int itID = sharedPreferences.getInt("itSupporterId", 0);
        reference1 = new Firebase("https://mystatus-2e32a.firebaseio.com/status/" + requestIDTime);
        final Map<String, String> map = new HashMap<String, String>();
        btnAccept = findViewById(R.id.btn1);
        btnAccept.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                map.put("status", "Đã nhận");
                map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                reference1.push().setValue(map);
            }
        });
        bt2 = findViewById(R.id.button2);
        bt2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                map.put("status", "Đang di chuyển");
                map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                reference1.push().setValue(map);
            }
        });
        bt3 = findViewById(R.id.button3);
        bt3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                map.put("status", "Đang sửa chữa");
                map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                reference1.push().setValue(map);
            }
        });
        bt4 = findViewById(R.id.button4);
        bt4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                map.put("status", "Đợi linh kiện");
                map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                reference1.push().setValue(map);
            }
        });

        bt5 = findViewById(R.id.button5);
        bt5.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                map.put("status", "Hoàn thành");
                map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                reference1.push().setValue(map);
                itSupporterService.updateBusyIT(StatusTimelineActivity.this, itID);

            }
        });

    }
}
