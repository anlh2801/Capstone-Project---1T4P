package com.odts.activities;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.odts.customTools.CancleRequestAdapter;
import com.odts.models.Request;
import com.odts.models.RequestGroupMonth;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;
import com.odts.utils.Enums;

import java.util.ArrayList;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * to handle interaction events.
 * create an instance of this fragment.
 */
public class CancleFragment extends Fragment {

    private RequestService requestService;
    private ListView listView;
    private CancleRequestAdapter cancleRequestAdapter;
    Integer agencyId = 0;

    public CancleFragment() {
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_cancle, container, false);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        agencyId = share.getInt("agencyId", 0);
        listView = (ListView) v.findViewById(R.id.listCancel) ;
        requestService = new RequestService();
        requestService.getRequestByStatusWithMonth(getActivity(), agencyId, Enums.RequestStatusEnum.Cancel.getIntValue(), new CallBackData<ArrayList<RequestGroupMonth>>() {
            @Override
            public void onSuccess(ArrayList<RequestGroupMonth> listRequests) {
                cancleRequestAdapter = new CancleRequestAdapter(getActivity(), R.layout.list_cancel_request_group_item, listRequests);
                listView.setAdapter(cancleRequestAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });
        return v;
    }

 }
