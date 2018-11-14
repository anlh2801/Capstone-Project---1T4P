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
import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.ResponseObjectReturnList;
import com.odts.it_supporter_app.utils.RetrofitInstance;

import java.time.LocalDateTime;
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
                if(!response.body().isError()){
                    callBackData.onSuccess(response.body().isError());
                }
                else {
                }

            }
            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });

    }
    public void updateStatusIT(final  Context context, int itsupporter_id, boolean isOnline) {
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
    public  void updateStartTime(final Context context, int request_id, String start_time) {
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
    public  void updateEndTime(final Context context, int request_id, String end_time) {
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
    public  void getIsOnline(final Context context, int itsupporter_id, final CallBackData<Boolean> callBackData) {
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

    public  void getIsBusy(final Context context, int itsupporter_id, final CallBackData<Boolean> callBackData) {
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
}
