package com.odts.it_supporter_app.activities;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Paint;
import android.net.Uri;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import com.firebase.client.Firebase;
import com.google.firebase.messaging.FirebaseMessaging;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.customTools.RequestITSupporterStatisticAdapter;
import com.odts.it_supporter_app.models.ITSupporterStatistic;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.lang.ref.Reference;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;


public class RecieveRequestFragment extends Fragment {
    private ITSupporterService _itSupporterService;
    Integer itSupporterId = 0;
    Integer requestId = 0;
    TextView txtTotalTimes, txtTotalTime;
    ListView lvRequestGroup;
    SharedPreferences share;
    SharedPreferences share2;
    String itSupportName;

    public RecieveRequestFragment() {
        _itSupporterService = new ITSupporterService();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_recieve_request, container, false);
        share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        share2 = getActivity().getApplicationContext().getSharedPreferences("firebaseData", Context.MODE_PRIVATE);
        itSupporterId = share.getInt("itSupporterId", 0);
        itSupportName = share.getString("itName", "");

        FirebaseMessaging.getInstance().subscribeToTopic(itSupporterId.toString());
        String a = share2.getString("AgencyName", null);
        this.requestId = Integer.parseInt(share2.getString("RequestId", "0"));
        if (a != null) {
            AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            View confirmView = getLayoutInflater().inflate(R.layout.receive_confirm, null);
            final Button acceptButton = confirmView.findViewById(R.id.btnAccept);
            final Button rejectButton = confirmView.findViewById(R.id.btnReject);
            final TextView requestName = confirmView.findViewById(R.id.txtRqName);
            final TextView agencyName = confirmView.findViewById(R.id.txtAgencyName);
            final TextView agencyAddress = confirmView.findViewById(R.id.txtAddress);
            final TextView ticketInfo = confirmView.findViewById(R.id.txtTicketInfo);
            requestName.setText(share2.getString("RequestName", "").toString());
            agencyName.setText(share2.getString("AgencyName", "").toString());
            agencyAddress.setText(share2.getString("AgencyAddress", "").toString());
            ticketInfo.setText(share2.getString("TicketsInfo", "").toString());
            builder.setView(confirmView);
            final AlertDialog dlg = builder.create();
            dlg.show();
            acceptButton.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    getAllServiceITSupportForAgency(true, "Accepted");
                    dlg.dismiss();
                    Firebase.setAndroidContext(getActivity());
                    Firebase reference1 = new Firebase("https://mystatus-2e32a.firebaseio.com/status/" + requestId);
                    final Map<String, String> map = new HashMap<String, String>();
                    map.put("status", "Đã nhận");
                    map.put("message", "bởi nhân viên: " + itSupportName);
                    map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                    reference1.push().setValue(map);
                }
            });
            rejectButton.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    dlg.dismiss();
                    LayoutInflater layoutInflaterAndroid = LayoutInflater.from(getContext());
                    View mView = layoutInflaterAndroid.inflate(R.layout.cause_by, null);
                    android.support.v7.app.AlertDialog.Builder alertDialogBuilderUserInput = new android.support.v7.app.AlertDialog.Builder(getContext());
                    alertDialogBuilderUserInput.setView(mView);
                    final EditText edittextAnother = mView.findViewById(R.id.edittextAnother);
                    final RadioButton rd1 = mView.findViewById(R.id.radioButton1);
                    rd1.setText("Đang ốm");
                    final RadioButton rd2 = mView.findViewById(R.id.radioButton2);
                    rd2.setText("Chuyện gia đình");
                    final RadioButton rd3 = mView.findViewById(R.id.radioButton3);
                    rd3.setText("Xe hỏng");
                    final RadioButton rd4 = mView.findViewById(R.id.radioButton4);
                    rd4.setText("Khác");
                    alertDialogBuilderUserInput
                            .setCancelable(false)
                            .setPositiveButton("Xác nhận", new DialogInterface.OnClickListener() {
                                public void onClick(final DialogInterface dialogBox, int id) {
                                    // ToDo get user input here
//                                    getAllServiceITSupportForAgency(false, "Timeout");
                                    if (rd1.isChecked()) {
                                        getAllServiceITSupportForAgency(false, rd1.getText().toString());
                                    } else if (rd2.isChecked()) {
                                        getAllServiceITSupportForAgency(false, rd2.getText().toString());
                                    } else if (rd3.isChecked()) {
                                        getAllServiceITSupportForAgency(false, rd3.getText().toString());
                                    } else {
                                        getAllServiceITSupportForAgency(false, edittextAnother.getText().toString());
                                    }
                                }
                            })
                            .setNegativeButton("Đóng",
                                    new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialogBox, int id) {
                                            getAllServiceITSupportForAgency(false, "Nothing");
                                            dialogBox.cancel();
                                        }
                                    });

                    android.support.v7.app.AlertDialog alertDialogAndroid = alertDialogBuilderUserInput.create();
                    alertDialogAndroid.show();
                }
            });
            String nowTime = share2.getString("Date", "");
            Calendar cal = Calendar.getInstance();
            Date date = cal.getTime();
            DateFormat dateFormat = new SimpleDateFormat("HH:mm:ss");
            String formattedDate = dateFormat.format(date);
            Date d1 = null;
            Date d2 = null;
            try {
                d1 = dateFormat.parse(nowTime);
                d2 = dateFormat.parse(formattedDate);
            } catch (ParseException e) {
                e.printStackTrace();
            }
            long diff = d2.getTime() - d1.getTime();
            long diffSeconds = 60000 - diff;
            int timeCountDown = 0;
            if (share2.getString("checkDate", "") != null) {
                timeCountDown = (int) diffSeconds;
            } else {
                timeCountDown = 60000;
            }
            new CountDownTimer(timeCountDown, 1000) {

                public void onTick(long millisUntilFinished) {
                    acceptButton.setText("Chấp nhận: " + millisUntilFinished / 1000);
                }

                public void onFinish() {
                    acceptButton.setText("Hết thời gian!");
                    getAllServiceITSupportForAgency(false, "Timeout");
                    dlg.dismiss();
                }
            }.start();
//            final Timer t = new Timer();
//            t.schedule(new TimerTask() {
//                public void run() {
//                    dlg.dismiss(); // when the task active then close the dialog
//                    t.cancel(); // also just top the timer thread, otherwise, you may receive a crash report
//                    getAllServiceITSupportForAgency(false);
//                }
//            }, 10000);
        }
//        txtAgencyNameRecieveRequest.setText(share2.getString("a", "").toString());
//        txtAgencyAddressRecieveRequest.setText(share2.getString("b", "").toString());
//        txtTicketInfoRecieveRequest.setText(share2.getString("c", "").toString());
//        txtRequestNameRecieveRequest.setText(share2.getString("d", "").toString());
        txtTotalTimes = v.findViewById(R.id.txtTotalTimesWailtingPage);
        txtTotalTime = v.findViewById(R.id.txtTotalTimeWailtingPage);
        lvRequestGroup = v.findViewById(R.id.lvRequestGroupWailtingPage);
        viewITsupporterStatisticToday(itSupporterId);
        return v;
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }


    private void getAllServiceITSupportForAgency(final boolean isAccept, String des) {
        _itSupporterService.acceptRequest(getActivity(), requestId, itSupporterId, isAccept, des, new CallBackData<Boolean>() {
            @Override
            public void onSuccess(Boolean aBoolean) {
                SharedPreferences.Editor editor2 = share2.edit();
                editor2.clear().commit();
                if (isAccept) {
                    moveToDoRequestFragment();
                } else {
                    Intent restartIntent = getActivity().getPackageManager().getLaunchIntentForPackage(getActivity().getPackageName());
                    restartIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                    startActivity(restartIntent);
                }
            }

            @Override
            public void onFail(String message) {
            }
        });
    }

    private void moveToDoRequestFragment() {
        SharedPreferences.Editor edit = share.edit();
        edit.putInt("requestId", requestId);
        SharedPreferences shareRequestID = getActivity().getSharedPreferences("ODTS", Context.MODE_PRIVATE);
        shareRequestID.edit().putInt("requestId", requestId);
        edit.commit();
        getActivity().getSupportFragmentManager()
                .beginTransaction()
                .setCustomAnimations(R.animator.enter_from_right, R.animator.exit_to_left, R.animator.enter_from_left, R.animator.exit_to_right)
                .replace(R.id.fmHome, new HeroFragment())
                .commit();
    }

    private void viewITsupporterStatisticToday(int itsupporter_id) {
        _itSupporterService = new ITSupporterService();
        _itSupporterService.viewITsupporterStatisticToday(getActivity(), itsupporter_id, new CallBackData<ITSupporterStatistic>() {
            @Override
            public void onSuccess(ITSupporterStatistic itSupporterStatistic) {
                txtTotalTimes.setText(itSupporterStatistic.getTotalTimesSupport().toString());
                txtTotalTime.setText(itSupporterStatistic.getTotalTimeSupport());
                RequestITSupporterStatisticAdapter requestITSupporterStatisticAdapter = new RequestITSupporterStatisticAdapter(getActivity(), R.layout.list_request_group_item, itSupporterStatistic.getRequestOfITSupporter());
                lvRequestGroup.setAdapter(requestITSupporterStatisticAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });
    }
}
