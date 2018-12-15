package com.odts.activities;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.InputType;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

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
    private SharedPreferences share;
    private TextView txtAgencyName, txtAdrr, txtPhone, txtCompanyName, txtUsername;
    ImageButton imgLogout;
    Integer agencyId;
    private AgencyService agencyService;

    public ProfileFragment() {
        agencyService = new AgencyService();
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        agencyId = share.getInt("agencyId", 0);
        getAgencyProfile(agencyId);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_profile, container, false);
        final SharedPreferences sharedPreferences = getContext().getSharedPreferences("ODTS", Context.MODE_PRIVATE);
        txtAgencyName = (TextView) v.findViewById(R.id.AgencyNameProfile);
        txtAdrr = (TextView) v.findViewById(R.id.AgencyAddressProfile);
        txtAdrr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                View confirmView = getLayoutInflater().inflate(R.layout.edit_text_dialog, null);
                final EditText etComments = confirmView.findViewById(R.id.etComments);
//                etComments.setInputType(InputType.TYPE_CLASS_NUMBER);
                builder.setView(confirmView);
                builder
                        .setCancelable(false)
                        .setPositiveButton("Xác nhận", new DialogInterface.OnClickListener() {
                            public void onClick(final DialogInterface dialogBox, int id) {
                                Agency agency = new Agency();
                                agency.setAgencyId(sharedPreferences.getInt("agencyId", 0));
                                agency.setAgencyName("");
                                agency.setAddress(etComments.getText().toString());
                                agency.setTelephone("");
                                agency.setPassword("");
                                agencyService.updateProfile(getContext(), agency);
                            }
                        })
                        .setNegativeButton("Đóng",
                                new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialogBox, int id) {
                                        dialogBox.cancel();
                                    }
                                });
                AlertDialog dlg = builder.create();
                dlg.show();
            }
        });
        txtCompanyName = (TextView) v.findViewById(R.id.CompanyNameProfile);
        txtPhone = (TextView) v.findViewById(R.id.PhoneNumber);
        txtPhone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                View confirmView = getLayoutInflater().inflate(R.layout.edit_text_dialog, null);
                final EditText etComments = confirmView.findViewById(R.id.etComments);
                etComments.setInputType(InputType.TYPE_CLASS_NUMBER);
                builder.setView(confirmView);
                builder
                        .setCancelable(false)
                        .setPositiveButton("Xác nhận", new DialogInterface.OnClickListener() {
                            public void onClick(final DialogInterface dialogBox, int id) {
                                Agency agency = new Agency();
                                agency.setAgencyId(sharedPreferences.getInt("agencyId", 0));
                                agency.setAgencyName("");
                                agency.setAddress("");
                                agency.setTelephone(etComments.getText().toString());
                                agency.setPassword("");
                                agencyService.updateProfile(getContext(), agency);
                            }
                        })
                        .setNegativeButton("Đóng",
                                new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialogBox, int id) {
                                        dialogBox.cancel();
                                    }
                                });
                AlertDialog dlg = builder.create();
                dlg.show();
            }
        });
        txtUsername = (TextView) v.findViewById(R.id.UsernameProfile);
        imgLogout = (ImageButton) v.findViewById(R.id.imgLogout);

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
        agencyService.getAgencyProfile(getActivity(), agencyId, new CallBackData<Agency>() {
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
