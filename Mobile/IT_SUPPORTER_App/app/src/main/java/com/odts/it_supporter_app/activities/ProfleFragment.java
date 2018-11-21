package com.odts.it_supporter_app.activities;

import android.content.Context;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.customTools.RatingAdapter;
import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.models.ITSupporterStatistic;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.models.RequestGroupMonth;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.utils.CallBackData;
import com.willy.ratingbar.ScaleRatingBar;

import java.util.ArrayList;

import me.zhanghai.android.materialratingbar.MaterialRatingBar;


public class ProfleFragment extends Fragment {
    SharedPreferences sharedPreferences;
    TextView itNameTxt, itPhoneTxt, txtRating;
    MaterialRatingBar ratingBar;
    ITSupporterService itSupporterService;
    RatingAdapter ratingAdapter;
    ListView listView;
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
        txtRating = v.findViewById(R.id.txtRating);
        listView = (ListView) v.findViewById(R.id.listRating);
        itSupporterService = new ITSupporterService();
        itSupporterService.viewProfile(getContext(), itID, new CallBackData<ITSupporter>() {
            @Override
            public void onSuccess(ITSupporter itSupporter) {
                String itName = itSupporter.getItSupporterName();
                Float itRating = itSupporter.getRatingAVG();
                itNameTxt.setText(itName.toString());
                txtRating.setText(itRating.toString());
            }

            @Override
            public void onFail(String message) {

            }
        });

        itSupporterService.viewAllFeedback(getContext(), itID, new CallBackData<ArrayList<RequestGroupMonth>>() {
            @Override
            public void onSuccess(ArrayList<RequestGroupMonth> listRating) {
                ratingAdapter = new RatingAdapter(getActivity(), R.layout.list_request_group_item, listRating);
                listView.setAdapter(ratingAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });
        return v;
    }

}
