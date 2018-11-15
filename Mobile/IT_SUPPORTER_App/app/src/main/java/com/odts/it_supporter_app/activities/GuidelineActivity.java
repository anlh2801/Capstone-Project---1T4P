package com.odts.it_supporter_app.activities;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.customTools.GuidelineAdapter;
import com.odts.it_supporter_app.models.Guideline;
import com.odts.it_supporter_app.services.GuidelineService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.util.ArrayList;

public class GuidelineActivity extends AppCompatActivity {

    Integer serviceItemId;
    String ServiceItemName;
    GuidelineService _guidelineService;

    public GuidelineActivity() {
        _guidelineService = new GuidelineService();
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_guideline);
        getAllServiceITSupportForAgency(1);
        TextView txtServiceItemNameGuidline = findViewById(R.id.txtServiceItemNameGuidline);
        txtServiceItemNameGuidline.setText("hahaha");
    }

    private void getAllServiceITSupportForAgency(int serviceItemId) {
        _guidelineService.getGuidelineByServiceItemID(this, serviceItemId, new CallBackData<ArrayList<Guideline>>() {
            @Override
            public void onSuccess(ArrayList<Guideline> guidelines) {
                ListView lvDeviceToManage = findViewById(R.id.lvGuidline);
                GuidelineAdapter guidelineAdapter = new GuidelineAdapter(GuidelineActivity.this, R.layout.guilde_line_item, guidelines);
                lvDeviceToManage.setAdapter(guidelineAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });
    }
}
