package com.odts.it_supporter_app.activities;

import android.content.Intent;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.customTools.GuidelineAdapter;
import com.odts.it_supporter_app.models.Guideline;
import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.services.GuidelineService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.util.ArrayList;

public class GuidelineActivity extends AppCompatActivity {

    Integer serviceItemId;
    Integer requestId;
    Integer itSupporterId;
    String ServiceItemName;
    GuidelineService _guidelineService;
    ArrayList<Guideline> guidelineRS;

    public GuidelineActivity() {
        _guidelineService = new GuidelineService();
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_guideline);


        TextView txtServiceItemNameGuidline = findViewById(R.id.txtServiceItemNameGuidline);
        requestId = getIntent().getIntExtra("requestId", 0);
        serviceItemId = getIntent().getIntExtra("serviceItemId", 0);
        itSupporterId = getIntent().getIntExtra("itSupporterId", 0);
        txtServiceItemNameGuidline.setText(getIntent().getStringExtra("serviceItemName"));
        getAllServiceITSupportForAgency(serviceItemId);

        FloatingActionButton flbAddTaskFromGuidline = findViewById(R.id.flbAddTaskFromGuidline);
        flbAddTaskFromGuidline.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ArrayList<RequestTask> requestTasks = new ArrayList<>();
                for (Guideline item: guidelineRS) {
                    RequestTask requestTask = new RequestTask();
                    requestTask.setRequestId(requestId);
                    requestTask.setTaskDetail(item.getGuidelineName());
                    requestTask.setCreateByITSupporter(itSupporterId);
                    requestTasks.add(requestTask);
                }
                _guidelineService.createTaskFromGuidline(GuidelineActivity.this, requestTasks);
                finish();

//                Intent myIntent = new Intent(GuidelineActivity.this, TaskActivity.class);
//                startActivity(myIntent);
            }
        });
    }

    private void getAllServiceITSupportForAgency(int serviceItemId) {
        _guidelineService.getGuidelineByServiceItemID(this, serviceItemId, new CallBackData<ArrayList<Guideline>>() {
            @Override
            public void onSuccess(ArrayList<Guideline> guidelines) {
                guidelineRS = guidelines;
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
