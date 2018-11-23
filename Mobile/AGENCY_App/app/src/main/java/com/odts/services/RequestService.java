package com.odts.services;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.Toast;

import com.odts.activities.MainActivity;
import com.odts.activities.PendingFragment;
import com.odts.apiCaller.IRequestApiCaller;
import com.odts.models.Rating;
import com.odts.models.Request;
import com.odts.models.RequestGroupMonth;
import com.odts.utils.CallBackData;
import com.odts.utils.ResponseObject;
import com.odts.utils.ResponseObjectReturnList;
import com.odts.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class RequestService {
    IRequestApiCaller IRequestApiCaller;
    private MainActivity main;

    public void createRequest(final Context context, Request request) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObject<Integer>> call = IRequestApiCaller.createRequest(request);
        call.enqueue(new Callback<ResponseObject<Integer>>() {
            @Override
            public void onResponse(Call<ResponseObject<Integer>> call, Response<ResponseObject<Integer>> response) {
                if (!response.body().isError()) {
                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    if (response.body().getObjReturn() != null && response.body().getObjReturn() > 0) {
                        findITSupporterByRequestId(context, response.body().getObjReturn());
                        Intent intent = new Intent(context, MainActivity.class);
                        context.startActivity(intent);
                    }
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<Integer>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }

    public void findITSupporterByRequestId(final Context context, int requestId) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<String> call = IRequestApiCaller.findITSupporterByRequestId(requestId);
        call.enqueue(new Callback<String>() {
            @Override
            public void onResponse(Call<String> call, Response<String> response) {
                Toast.makeText(context, response.body(), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<String> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }

    public void getRequestByStatus(final Context context, Integer agency_id, Integer status, final CallBackData<ArrayList<Request>> callBackData) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObjectReturnList<Request>> call = IRequestApiCaller.getRequestByStatus(agency_id, status);
        call.enqueue(new Callback<ResponseObjectReturnList<Request>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<Request>> call, Response<ResponseObjectReturnList<Request>> response) {
                if (!response.body().isError()) {
//                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    callBackData.onSuccess(response.body().getObjList());
                }
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<Request>> call, Throwable t) {

            }
        });
    }

    public void getRequestByStatusWithMonth(final Context context, Integer agency_id, Integer status, final CallBackData<ArrayList<RequestGroupMonth>> callBackData) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObjectReturnList<RequestGroupMonth>> call = IRequestApiCaller.getRequestByStatusWithMonth(agency_id, status);
        call.enqueue(new Callback<ResponseObjectReturnList<RequestGroupMonth>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<RequestGroupMonth>> call, Response<ResponseObjectReturnList<RequestGroupMonth>> response) {
                if (!response.body().isError()) {
//                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    callBackData.onSuccess(response.body().getObjList());
                }
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<RequestGroupMonth>> call, Throwable t) {

            }
        });
    }

    public void requestDetail(final Context context, Integer request_id, final CallBackData<Request> callBackData) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObject<Request>> call = IRequestApiCaller.requestDetail(request_id);
        call.enqueue(new Callback<ResponseObject<Request>>() {
            @Override
            public void onResponse(Call<ResponseObject<Request>> call, Response<ResponseObject<Request>> response) {
                callBackData.onSuccess(response.body().getObjReturn());
                SharedPreferences share = context.getSharedPreferences("ODTS", 0);
                SharedPreferences.Editor edit = share.edit();
                edit.putString("requestName", response.body().getObjReturn().getRequestName());
                edit.commit();
            }

            @Override
            public void onFailure(Call<ResponseObject<Request>> call, Throwable t) {

            }
        });

    }

    public void cancelTicket(final Context context, Integer request_id, Integer status_id) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObject<Boolean>> call = IRequestApiCaller.cancelTicket(request_id, status_id);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {

            }
        });

    }

    public void ratingHero(final Context context, Rating rating) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObject<Boolean>> call = IRequestApiCaller.ratingHero(rating);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                if (!response.body().isError()) {
                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    if (response.body().getObjReturn() != null && response.body().getObjReturn() == true) {
//                        findITSupporterByRequestId(context, response.body().getObjReturn());
                        Intent intent = new Intent(context, MainActivity.class);
                        context.startActivity(intent);
                    }
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }
}
