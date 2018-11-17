package com.odts.it_supporter_app.activities;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.support.v4.content.ContextCompat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.getbase.floatingactionbutton.FloatingActionsMenu;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.services.RequestService;
import com.odts.it_supporter_app.utils.CallBackData;


public class DoRequestFragment extends Fragment {
    private RequestService _requestService;

    Button btnDone, btnStart, btnTimeLine;
    com.getbase.floatingactionbutton.FloatingActionButton btnCall , btnChat , flbGuidline;
    Integer itSupporterId = 0;
    Integer requestId = 0;
    RequestService requestService;
    ITSupporterService itSupporterService;
    TextView rqName;
    String serviceItemName;
    Integer serviceItemId = 0;

    public DoRequestFragment() {
        _requestService = new RequestService();

    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v = inflater.inflate(R.layout.fragment_do_request, container, false);
        final FloatingActionsMenu menu = v.findViewById(R.id.multiple_actions);
        btnCall = v.findViewById(R.id.action_a);
        btnChat = v.findViewById(R.id.action_b);
        btnTimeLine = v.findViewById(R.id.btnTime);
        requestService = new RequestService();
        itSupporterService = new ITSupporterService();
        rqName = (TextView) v.findViewById(R.id.txtRequestName);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        itSupporterId = share.getInt("itSupporterId", 0);
        requestService.getRequestByRequestIdAndITSupporterId(getActivity(), itSupporterId, new CallBackData<Request>() {
            @Override
            public void onSuccess(final Request request) {
                requestId = request.getRequestId();
                serviceItemId = request.getServiceItemId();
                serviceItemName = request.getServiceItemName();
                rqName.setText(request.getRequestName());
                btnCall.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        menu.collapse();
                        Intent callIntent = new Intent(Intent.ACTION_CALL);
                        callIntent.setData(Uri.parse("tel: " + request.getPhoneNumber()));
                        if (ContextCompat.checkSelfPermission(getActivity().getApplicationContext(), Manifest.permission.CALL_PHONE) == PackageManager.PERMISSION_GRANTED) {
                            startActivity(callIntent);
                        } else {
                            requestPermissions(new String[]{Manifest.permission.CALL_PHONE}, 1);
                        }
                    }
                });

                btnChat.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        menu.collapse();
                        Intent intent = new Intent(getActivity(), ChatActivity.class);
                        startActivity(intent);
                    }
                });

                btnTimeLine.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        Intent intent = new Intent(getActivity(), StatusTimelineActivity.class);
                        intent.putExtra("requestIDTime", request.getRequestId());
                        startActivity(intent);
                    }
                });
            }

            @Override
            public void onFail(String message) {
            }
        });
//        btnDone = v.findViewById(R.id.btnDone);
//        btnDone.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                _requestService.updateStatusRequest(getContext(), requestId, Enums.RequestStatusEnum.Done.getIntValue());
//            }
//        });
//        btnStart = v.findViewById(R.id.btnStart);
//        btnStart.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                itSupporterService.updateStartTime(getContext(), requestId, DateFormat.getDateTimeInstance().format(new Date()));
//            }
//        });
        flbGuidline =  v.findViewById(R.id.action_c);
        flbGuidline.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                menu.collapse();
                Intent intent = new Intent(getContext(), GuidelineActivity.class);
                intent.putExtra("serviceItemName", serviceItemName);
                intent.putExtra("serviceItemId", serviceItemId);
                intent.putExtra("requestId", requestId);
                intent.putExtra("itSupporterId", itSupporterId);
                startActivity(intent);
            }
        });
        return v;
    }


}
