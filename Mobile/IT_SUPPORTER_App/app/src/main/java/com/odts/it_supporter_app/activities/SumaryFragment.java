package com.odts.it_supporter_app.activities;

import android.content.Context;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.customTools.GuidelineAdapter;
import com.odts.it_supporter_app.customTools.RequestITSupporterStatisticAdapter;
import com.odts.it_supporter_app.models.Guideline;
import com.odts.it_supporter_app.models.ITSupporterStatistic;
import com.odts.it_supporter_app.services.GuidelineService;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.util.ArrayList;
import java.util.List;


public class SumaryFragment extends Fragment {

    TextView txtTotalTimes, txtTotalTime, txtTotalTimesThisMonth, txtTotalTimeThisMonth;
    ListView lvRequestGroup;
    ITSupporterService _itSupporterService;
    Integer itSupporterId = 0;

    public SumaryFragment() {
        _itSupporterService = new ITSupporterService();
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        itSupporterId = share.getInt("itSupporterId", 0);
        viewITsupporterStatistic(itSupporterId);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_sumary, container, false);
        txtTotalTimes = v.findViewById(R.id.txtTotalTimes);
        txtTotalTime = v.findViewById(R.id.txtTotalTime);
        txtTotalTimesThisMonth = v.findViewById(R.id.txtTotalTimesThisMonth);
        txtTotalTimeThisMonth = v.findViewById(R.id.txtTotalTimeThisMonth);
        lvRequestGroup = v.findViewById(R.id.lvRequestGroup);

        return v;
    }

    private void viewITsupporterStatistic(int itsupporter_id) {
        _itSupporterService.viewITsupporterStatistic(getActivity(), itsupporter_id, new CallBackData<ITSupporterStatistic>() {
            @Override
            public void onSuccess(ITSupporterStatistic itSupporterStatistic) {

                RequestITSupporterStatisticAdapter requestITSupporterStatisticAdapter = new RequestITSupporterStatisticAdapter(getActivity(), R.layout.guilde_line_item, itSupporterStatistic.getRequestOfITSupporter());
                lvRequestGroup.setAdapter(requestITSupporterStatisticAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });
    }


}
