package com.odts.activities;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import com.odts.customTools.TimeLineAdapter;
import com.odts.models.Request;
import com.odts.models.Ticket;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by HP-HP on 05-12-2015.
 */
public class TimeLineActivity extends AppCompatActivity {

    private RecyclerView mRecyclerView;
    private TimeLineAdapter mTimeLineAdapter;
    private List<Ticket> mDataList = new ArrayList<>();
    RequestService requestService;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_timeline);

        mRecyclerView = (RecyclerView) findViewById(R.id.recyclerView);
        mRecyclerView.setLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.VERTICAL, false));
        mRecyclerView.setHasFixedSize(true);
        initView();
    }

    private void initView() {
        setDataListItems();
        mTimeLineAdapter = new TimeLineAdapter(mDataList);
        mRecyclerView.setAdapter(mTimeLineAdapter);
    }

    private void setDataListItems(){
        requestService = new RequestService();
        requestService.requestDetail(TimeLineActivity.this, 216, new CallBackData<Request>() {
            @Override
            public void onSuccess(Request listRequest) {
                listRequest.getTicket().get(0).getiTSupporterName();
                mDataList.add(new Ticket("Thực hiện bởii: " +listRequest.getTicket().get(0).getiTSupporterName(),1, listRequest.getTicket().get(0).getStartTime()  ));
                mDataList.add(new Ticket("Thời gian dự kiến:",  2, listRequest.getTicket().get(0).getTicketEstimationTime() ));
                mDataList.add(new Ticket("Thời gian kết thúc",  3, listRequest.getTicket().get(0).getEndTime() ));
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
}
