package com.odts.it_supporter_app.activities;

import android.content.Context;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.models.ITSupporterStatistic;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.utils.CallBackData;
import com.willy.ratingbar.ScaleRatingBar;

import java.util.ArrayList;


public class ProfleFragment extends Fragment {
    SharedPreferences sharedPreferences;
    TextView itNameTxt, itPhoneTxt, itEmailTxt;
    ScaleRatingBar ratingBar;
    ITSupporterService itSupporterService;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_profle, container, false);
        sharedPreferences = getActivity().getSharedPreferences("ODTS", Context.MODE_PRIVATE);
        final int itID = sharedPreferences.getInt("itSupporterId", 0);
        itNameTxt = v.findViewById(R.id.txtitNamePro);
        itPhoneTxt = v.findViewById(R.id.txtPhonePro);
        itEmailTxt = v.findViewById(R.id.txtEmailPro);
        ratingBar = v.findViewById(R.id.simpleRatingBar);
        ratingBar.setClearRatingEnabled(false);
        itSupporterService = new ITSupporterService();
        itSupporterService.viewProfile(getContext(), itID, new CallBackData<ITSupporter>() {
            @Override
            public void onSuccess(ITSupporter itSupporter) {
                String itName = itSupporter.getItSupporterName();
                String itPhone = itSupporter.getTelephone();
                String itEmail = itSupporter.getEmail();
                Float itRating = itSupporter.getRatingAVG();
                ratingBar.setRating(itRating);
                itNameTxt.setText(itName.toString());
                itPhoneTxt.setText(itPhone.toString());
                itEmailTxt.setText(itEmail.toString());
            }

            @Override
            public void onFail(String message) {

            }
        });

        itSupporterService.viewAllFeedback(getContext(), itID, new CallBackData<ArrayList<Request>>() {
            @Override
            public void onSuccess(ArrayList<Request> requests) {
                
            }

            @Override
            public void onFail(String message) {

            }
        });
        return v;
    }

}
