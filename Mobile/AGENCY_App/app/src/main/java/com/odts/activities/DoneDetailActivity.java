package com.odts.activities;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v4.app.FragmentActivity;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import com.odts.models.Rating;
import com.odts.models.Request;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;
import com.stepstone.apprating.AppRatingDialog;
import com.stepstone.apprating.listener.RatingDialogListener;

public class DoneDetailActivity extends AppCompatActivity implements RatingDialogListener{
    private Button btnRatingDone;
    private RequestService requestService;
    int requestID = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_done_detail);
        btnRatingDone = (Button) findViewById(R.id.btnRatingDone);
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
        Intent myIntent = getIntent();
        requestID = myIntent.getIntExtra("requestID", 0);
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
        requestService.ratingHero(DoneDetailActivity.this,rating);
    }
}
