package com.odts.it_supporter_app.activities;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.InputType;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
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
    TextView itNameTxt, itPhoneTxt, txtRating, txtPhone;
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
        txtPhone = v.findViewById(R.id.txtPhone);
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
                                ITSupporter itSupporter = new ITSupporter();
                                itSupporter.setItSupporterId(itID);
                                itSupporter.setTelephone(etComments.getText().toString());
                                itSupporterService.updateProfile(getContext(), itSupporter);
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
        listView = (ListView) v.findViewById(R.id.listRating);
        itSupporterService = new ITSupporterService();
        itSupporterService.viewProfile(getContext(), itID, new CallBackData<ITSupporter>() {
            @Override
            public void onSuccess(ITSupporter itSupporter) {
                String itName = itSupporter.getItSupporterName();
                Float itRating = itSupporter.getRatingAVG();
                itNameTxt.setText(itName.toString());
                txtRating.setText(itRating.toString());
                txtPhone.setText(itSupporter.getTelephone());
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
