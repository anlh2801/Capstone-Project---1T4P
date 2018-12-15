package com.odts.activities;

import android.content.Context;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.customTools.AgencyStatisticalAdapter;
import com.odts.customTools.ServiceItemAdapter;
import com.odts.models.AgencyStatistical;
import com.odts.models.ServiceItem;
import com.odts.services.ServiceITSupportService;
import com.odts.services.ServiceItemService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;


public class NewHomeFragment extends Fragment {


    private ServiceITSupportService _serviceITSupportService;
    private ServiceItemService _serviceItem;

    Integer agencyId = 0;
    String agencyName;
    String agencyAddr;
    public NewHomeFragment() {
        _serviceITSupportService = new ServiceITSupportService();
        _serviceItem = new ServiceItemService();
    }
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        agencyId = share.getInt("agencyId", 0);
        agencyName = share.getString("agencyName", "");
        agencyAddr = share.getString("agencyAddr", "");
        getAllServiceItemByServiceId(agencyId);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_new_home, container, false);
        TextView txtAgencyName = v.findViewById(R.id.txtAgencyName);
        txtAgencyName.setText(agencyName.toString());
        return v;
    }


    public void getAllServiceItemByServiceId(int agencyId) {
        _serviceItem.getAgencyStatistic(getActivity(), agencyId, new CallBackData<ArrayList<AgencyStatistical>>() {
            @Override
            public void onSuccess(ArrayList<AgencyStatistical> serviceItems) {
                ListView lvAgencyStatistical = getActivity().findViewById(R.id.lvAgencyStatistical);
                AgencyStatisticalAdapter agencyStatisticalAdapter = new AgencyStatisticalAdapter(getActivity(), R.layout.service_item_list, serviceItems);
                lvAgencyStatistical.setAdapter(agencyStatisticalAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

}
