package com.odts.it_supporter_app.services;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.RelativeLayout;
import android.widget.Toast;

import com.odts.it_supporter_app.activities.MainActivity;
import com.odts.it_supporter_app.apiCaller.IITSupporterApiCaller;
import com.odts.it_supporter_app.apiCaller.ILoginApiCaller;
import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.models.ITSupporterStatistic;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.models.RequestGroupMonth;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.ResponseObjectReturnList;
import com.odts.it_supporter_app.utils.RetrofitInstance;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Date;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ITSupporterService {
    IITSupporterApiCaller iitSupporterApiCaller;

    public void acceptRequest(final Context context, int requestId, int itSupporterId, boolean isAccept, final CallBackData<Boolean> callBackData) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<Boolean>> call = iitSupporterApiCaller.acceptRequest(itSupporterId, requestId, isAccept);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                if (!response.body().isError()) {
                    callBackData.onSuccess(response.body().isError());
                } else {
                }

            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {

            }
        });

    }

    public void updateStatusIT(final Context context, int itsupporter_id, boolean isOnline) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<Boolean>> call = iitSupporterApiCaller.updateStatusIt(itsupporter_id, isOnline);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {

            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {

            }
        });
    }

    public void updateBusyIT(final Context context, int itsupporter_id) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<Boolean>> call = iitSupporterApiCaller.updateBusyIt(itsupporter_id);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {

            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {

            }
        });
    }

    public void updateStartTime(final Context context, int request_id, String start_time) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<Boolean>> call = iitSupporterApiCaller.updateStartTime(request_id, start_time);
        call.enqueue((new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {

            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {

            }
        }));
    }

    public void updateEndTime(final Context context, int request_id, String end_time) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<Boolean>> call = iitSupporterApiCaller.updateEndTime(request_id, end_time);
        call.enqueue((new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {

            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {

            }
        }));
    }

    public void getIsOnline(final Context context, int itsupporter_id, final CallBackData<Boolean> callBackData) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<Boolean>> call = iitSupporterApiCaller.getIsOnline(itsupporter_id);
        call.enqueue((new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                callBackData.onSuccess(response.body().getObjReturn());
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {

            }
        }));
    }

    public void getIsBusy(final Context context, int itsupporter_id, final CallBackData<Boolean> callBackData) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<Boolean>> call = iitSupporterApiCaller.getIsBusy(itsupporter_id);
        call.enqueue((new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                callBackData.onSuccess(response.body().getObjReturn());
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {

            }
        }));
    }

    public void viewProfile(final Context context, int itsupporter_id, final CallBackData<ITSupporter> callBackData) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<ITSupporter>> call = iitSupporterApiCaller.viewProfile(itsupporter_id);
        call.enqueue((new Callback<ResponseObject<ITSupporter>>() {
            @Override
            public void onResponse(Call<ResponseObject<ITSupporter>> call, Response<ResponseObject<ITSupporter>> response) {
                callBackData.onSuccess(response.body().getObjReturn());
            }

            @Override
            public void onFailure(Call<ResponseObject<ITSupporter>> call, Throwable t) {

            }
        }));
    }

    public void viewITsupporterStatistic(final Context context, int itsupporter_id, final CallBackData<ITSupporterStatistic> callBackData) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<ITSupporterStatistic>> call = iitSupporterApiCaller.viewITsupporterStatistic(itsupporter_id);
        call.enqueue((new Callback<ResponseObject<ITSupporterStatistic>>() {
            @Override
            public void onResponse(Call<ResponseObject<ITSupporterStatistic>> call, Response<ResponseObject<ITSupporterStatistic>> response) {
                callBackData.onSuccess(response.body().getObjReturn());
            }

            @Override
            public void onFailure(Call<ResponseObject<ITSupporterStatistic>> call, Throwable t) {
            }
        }));
    }

    public void viewITsupporterStatisticToday(final Context context, int itsupporter_id, final CallBackData<ITSupporterStatistic> callBackData) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<ITSupporterStatistic>> call = iitSupporterApiCaller.viewITsupporterStatisticToday(itsupporter_id);
        call.enqueue((new Callback<ResponseObject<ITSupporterStatistic>>() {
            @Override
            public void onResponse(Call<ResponseObject<ITSupporterStatistic>> call, Response<ResponseObject<ITSupporterStatistic>> response) {
                callBackData.onSuccess(response.body().getObjReturn());
            }

            @Override
            public void onFailure(Call<ResponseObject<ITSupporterStatistic>> call, Throwable t) {
            }
        }));
    }

    public void viewAllFeedback(final Context context, int itsupporter_id, final CallBackData<ArrayList<RequestGroupMonth>> callBackData) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObjectReturnList<RequestGroupMonth>> call = iitSupporterApiCaller.viewAllFeedback(itsupporter_id);
        call.enqueue((new Callback<ResponseObjectReturnList<RequestGroupMonth>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<RequestGroupMonth>> call, Response<ResponseObjectReturnList<RequestGroupMonth>> response) {
                if (!response.body().isError()) {
                    callBackData.onSuccess(response.body().getObjList());
                }
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<RequestGroupMonth>> call, Throwable t) {

            }
        }));
    }

    public void checkDeviceInfo(final Context context, String deviceCode, final CallBackData<Device> callBackData) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<Device>> call = iitSupporterApiCaller.checkDeviceInfo(deviceCode);
        call.enqueue((new Callback<ResponseObject<Device>>() {
            @Override
            public void onResponse(Call<ResponseObject<Device>> call, Response<ResponseObject<Device>> response) {
                callBackData.onSuccess(response.body().getObjReturn());
            }

            @Override
            public void onFailure(Call<ResponseObject<Device>> call, Throwable t) {
            }
        }));
    }

}
