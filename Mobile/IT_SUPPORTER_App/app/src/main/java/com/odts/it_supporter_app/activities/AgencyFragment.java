package com.odts.it_supporter_app.activities;

import android.content.Context;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.services.RequestService;
import com.odts.it_supporter_app.utils.CallBackData;

/**

 * create an instance of this fragment.
 */
public class AgencyFragment extends android.support.v4.app.Fragment {

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *

     * @return A new instance of fragment AgencyFragment.
     */
    // TODO: Rename and change types and number of parameters

    RequestService requestService;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_agency, container, false);
        final TextView agencyName = v.findViewById(R.id.txtAgency);
        final TextView rqName = (TextView) v.findViewById(R.id.txtRequestName);
        final TextView priority = v.findViewById(R.id.txtPrio);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        int itSupporterId = share.getInt("itSupporterId", 0);
        requestService = new RequestService();
        requestService.getRequestByRequestIdAndITSupporterId(getActivity(), itSupporterId, new CallBackData<Request>() {
            @Override
            public void onSuccess(Request request) {
                agencyName.setText(request.getAgencyName());
                rqName.setText(request.getRequestName());
                priority.setText(request.getPriority());
            }

            @Override
            public void onFail(String message) {

            }
        });
        return v;
    }

}
