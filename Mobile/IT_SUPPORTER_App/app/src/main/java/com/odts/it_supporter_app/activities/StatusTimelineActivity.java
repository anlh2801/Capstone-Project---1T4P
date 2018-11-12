package com.odts.it_supporter_app.activities;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import com.firebase.client.Firebase;
import com.odts.it_supporter_app.R;

import java.text.DateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

public class StatusTimelineActivity extends AppCompatActivity {
    Button btnAccept, bt2, bt3, bt4, bt5;
    Firebase reference1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_status_timeline);
        Firebase.setAndroidContext(this);
        reference1 = new Firebase("https://mystatus-2e32a.firebaseio.com/status/216");
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
            }
        });

    }
}
