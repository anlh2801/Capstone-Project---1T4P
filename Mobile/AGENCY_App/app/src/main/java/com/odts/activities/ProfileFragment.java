package com.odts.activities;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.customTools.DeviceManageAdapter;
import com.odts.models.Agency;
import com.odts.models.Device;
import com.odts.services.AgencyService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * to handle interaction events.
 * create an instance of this fragment.
 */
public class ProfileFragment extends Fragment {
    private Button btnLogoutt;
    private SharedPreferences share;
    private TextView txtAgencyName, txtAdrr, txtPhone, txtCompanyName, txtUsername;
    ImageButton imgLogout;
    Integer agencyId;
    private AgencyService _agencyService;

    public ProfileFragment() {
        _agencyService = new AgencyService();
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        agencyId = share.getInt("agencyId", 0);
        getAgencyProfile(agencyId);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_profile, container, false);

        txtAgencyName = (TextView) v.findViewById(R.id.AgencyNameProfile);
        txtAdrr = (TextView) v.findViewById(R.id.AgencyAddressProfile);
        txtCompanyName = (TextView) v.findViewById(R.id.CompanyNameProfile);
        txtPhone = (TextView) v.findViewById(R.id.PhoneNumber);
        txtUsername = (TextView) v.findViewById(R.id.UsernameProfile);
        imgLogout = (ImageButton) v.findViewById(R.id.imgLogout);

        //btnLogoutt = (Button) v.findViewById(R.id.btnLogout);
        imgLogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                share = getActivity().getSharedPreferences("login", Context.MODE_PRIVATE);
                SharedPreferences.Editor editor = share.edit();
                editor.clear();
                editor.commit();
                Intent intent = new Intent(getActivity(), LoginActivity.class);
                startActivity(intent);
            }
        });
        return v;
    }


    private void getAgencyProfile(int agencyId) {
        _agencyService.getAgencyProfile(getActivity(), agencyId, new CallBackData<Agency>() {
            @Override
            public void onSuccess(Agency agency) {
                txtAgencyName.setText(agency.getAgencyName());
                txtAdrr.setText(agency.getAddress());
                txtPhone.setText(agency.getTelephone());
                txtCompanyName.setText(agency.getCompanyName());
                txtUsername.setText(agency.getUserName());
            }

            @Override
            public void onFail(String message) {

            }
        });
    }
}
