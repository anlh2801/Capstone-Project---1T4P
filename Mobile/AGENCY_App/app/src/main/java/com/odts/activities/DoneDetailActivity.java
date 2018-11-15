package com.odts.activities;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v4.app.FragmentActivity;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.firebase.client.ChildEventListener;
import com.firebase.client.DataSnapshot;
import com.firebase.client.Firebase;
import com.firebase.client.FirebaseError;
import com.odts.customTools.StatusTimeLineAdapter;
import com.odts.models.Rating;
import com.odts.models.Request;
import com.odts.models.TimeLine;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;
import com.stepstone.apprating.AppRatingDialog;
import com.stepstone.apprating.listener.RatingDialogListener;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class DoneDetailActivity extends AppCompatActivity implements RatingDialogListener {
    private RecyclerView mRecyclerView;
    private StatusTimeLineAdapter mTimeLineAdapter;
    private List<TimeLine> mDataList = new ArrayList<>();
    private Button btnRatingDone;
    private RequestService requestService;
    int requestID = 0;
    Firebase reference1;
    private TextView itNamee, requestNamee, listDeviceNamee;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_done_detail);

        btnRatingDone = (Button) findViewById(R.id.btnRatingDone);
        mRecyclerView = (RecyclerView) findViewById(R.id.recyclerViewDone);
        itNamee = findViewById(R.id.itNameDone);
        requestNamee = findViewById(R.id.requestNameDone);
        listDeviceNamee = findViewById(R.id.listDeviceNameeDone);

        Intent myIntent = getIntent();
        requestID = myIntent.getIntExtra("requestID", 0);
        String itName = myIntent.getStringExtra("itName");
        itNamee.setText(itName);
        String requestName = myIntent.getStringExtra("requestName");
        requestNamee.setText(requestName);

        final ArrayList<String> listDeviceName = myIntent.getStringArrayListExtra("listDevice");
        StringBuilder sb = new StringBuilder();
        boolean foundOne = false;
        for (int i = 0; i < listDeviceName.size(); ++i) {
            if (foundOne) {
                sb.append(", ");
            }
            foundOne = true;
            sb.append(listDeviceName.get(i));
        }

        listDeviceNamee.setText(sb.toString());
        mRecyclerView.setLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.VERTICAL, false));
        mRecyclerView.setHasFixedSize(true);
        Firebase.setAndroidContext(this);
        reference1 = new Firebase("https://mystatus-2e32a.firebaseio.com/status/" + requestID);
        reference1.addChildEventListener(new ChildEventListener() {
            @Override
            public void onChildAdded(DataSnapshot dataSnapshot, String s) {
                Map map = dataSnapshot.getValue(Map.class);
                String message = map.get("status").toString();
                String time = map.get("time").toString();
                setDataListItems(message, time);
            }

            @Override
            public void onChildChanged(DataSnapshot dataSnapshot, String s) {

            }

            @Override
            public void onChildRemoved(DataSnapshot dataSnapshot) {

            }

            @Override
            public void onChildMoved(DataSnapshot dataSnapshot, String s) {

            }

            @Override
            public void onCancelled(FirebaseError firebaseError) {

            }
        });


        btnRatingDone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                new AppRatingDialog.Builder()
                        .setPositiveButtonText("Đánh giá")
                        .setNegativeButtonText("Hủy")
                        //.setNeutralButtonText("Later")
                        .setDefaultRating(0)
                        .setNumberOfStars(5)
                        .setStarColor(R.color.accent)
                        .setNoteDescriptionTextColor(R.color.accent)
                        .setTitleTextColor(R.color.colorAccent)
                        .setDescriptionTextColor(R.color.descriptionTextColor)
                        .setCommentTextColor(R.color.colorAccent)
                        .setCommentBackgroundColor(R.color.noteDescriptionTextColor)
                        .setWindowAnimation(R.style.MyDialogSlideHorizontalAnimation)
                        .setTitle("Đánh giá nhân viên sửa chữa")
                        .setDescription("Vui lòng đóng góp cho chúng tôi, để có thể phục vụ tốt hơn")
                        .setHint("Ghi chú thêm...")
                        .setHintTextColor(R.color.hintTextColor)
                        .setCancelable(false)
                        .setCanceledOnTouchOutside(false)
                        .create(DoneDetailActivity.this)
                        .show();
            }
        });
    }

    private void setDataListItems(String message, String time) {
        mDataList.add(new TimeLine(message, time));
        mTimeLineAdapter = new StatusTimeLineAdapter(mDataList);
        mRecyclerView.setAdapter(mTimeLineAdapter);
        mRecyclerView.post(new Runnable() {
            @Override
            public void run() {
                // Call smooth scroll
                mRecyclerView.smoothScrollToPosition(mTimeLineAdapter.getItemCount());
            }
        });
    }

    @Override
    public void onNegativeButtonClicked() {

    }

    @Override
    public void onNeutralButtonClicked() {

    }

    @Override
    public void onPositiveButtonClicked(int i, String s) {
        requestService = new RequestService();
        Rating rating = new Rating(requestID, i, s);
        requestService.ratingHero(DoneDetailActivity.this, rating);
    }
}
