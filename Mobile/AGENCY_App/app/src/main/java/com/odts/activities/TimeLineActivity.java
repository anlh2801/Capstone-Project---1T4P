package com.odts.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import com.odts.customTools.TimeLineAdapter;
import com.odts.models.Request;
import com.odts.models.Ticket;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;
import java.util.List;
import com.stepstone.apprating.AppRatingDialog;
import com.stepstone.apprating.listener.RatingDialogListener;

/**
 * Created by HP-HP on 05-12-2015.
 */
public class TimeLineActivity extends AppCompatActivity implements RatingDialogListener {

    private RecyclerView mRecyclerView;
    private TimeLineAdapter mTimeLineAdapter;
    private List<Ticket> mDataList = new ArrayList<>();
    RequestService requestService;
    Button btnChat;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_timeline);

        mRecyclerView = (RecyclerView) findViewById(R.id.recyclerView);
        mRecyclerView.setLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.VERTICAL, false));
        mRecyclerView.setHasFixedSize(true);
        setDataListItems();
        initView();
        btnChat = (Button) findViewById(R.id.btnChat);
        btnChat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(TimeLineActivity.this, ChatActivity.class);
                startActivity(intent);
            }
        });
    }

    private void initView() {
//        setDataListItems();
        mTimeLineAdapter = new TimeLineAdapter(mDataList);
        mRecyclerView.setAdapter(mTimeLineAdapter);
    }

    private void setDataListItems(){
        requestService = new RequestService();
        requestService.requestDetail(TimeLineActivity.this, 216, new CallBackData<Request>() {
            @Override
            public void onSuccess(Request listRequest) {
//                listRequest.getTicket().get(0).getiTSupporterName();
//                mDataList.add(new Ticket("Thực hiện bởii: " +listRequest.getServiceItemId(),1, listRequest.getTicket().get(0).getStartTime()  ));
//                mDataList.add(new Ticket("Thời gian dự kiến:",  2, listRequest.getTicket().get(0).getTicketEstimationTime() ));
//                mDataList.add(new Ticket("Thời gian kết thúc",  3, listRequest.getTicket().get(0).getEndTime() ));
                mDataList.add(new Ticket("asd", 1, ""));
            }
            @Override
            public void onFail(String message) {
            }
        });
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        //Menu
        switch (item.getItemId()) {
            //When home is clicked
            case android.R.id.home:
                onBackPressed();
                return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    protected void onSaveInstanceState(Bundle savedInstanceState) {
        super.onSaveInstanceState(savedInstanceState);
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
    }

    @Override
    public void onNegativeButtonClicked() {

    }

    @Override
    public void onNeutralButtonClicked() {

    }

    @Override
    public void onPositiveButtonClicked(int i, String s) {
        
    }
}
