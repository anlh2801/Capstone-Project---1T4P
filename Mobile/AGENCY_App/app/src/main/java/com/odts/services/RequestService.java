package com.odts.services;

import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.Toast;

import com.odts.activities.RequestActivity;
import com.odts.apiCaller.IRequestApiCaller;
import com.odts.models.ListRequest;
import com.odts.models.Request;
import com.odts.models.ServiceItem;
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
    public void addRequest(final Context context, Request request) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObject<Boolean>> call = IRequestApiCaller.addUser(request);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                if(!response.body().isError()){
                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                }
                else
                    Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }
    public void getRequestByStatus(final Context context, Integer agency_id, Integer status, final CallBackData<ArrayList<ListRequest>> callBackData) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObjectReturnList<ListRequest>> call = IRequestApiCaller.getRequestByStatus(agency_id, status);
        call.enqueue(new Callback<ResponseObjectReturnList<ListRequest>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<ListRequest>> call, Response<ResponseObjectReturnList<ListRequest>> response) {
                if(!response.body().isError()){
                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    callBackData.onSuccess(response.body().getObjList());
                }
                else
                    Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<ListRequest>> call, Throwable t) {

            }
        });
    }
    public void requestDetail(final Context context, Integer request_id, final CallBackData<ListRequest> callBackData) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObject<ListRequest>> call = IRequestApiCaller.requestDetail(request_id);
        call.enqueue(new Callback<ResponseObject<ListRequest>>() {
            @Override
            public void onResponse(Call<ResponseObject<ListRequest>> call, Response<ResponseObject<ListRequest>> response) {
                callBackData.onSuccess(response.body().getObjReturn());
                SharedPreferences share = context.getSharedPreferences("ODTS", 0);
                SharedPreferences.Editor edit = share.edit();
                edit.putString("requestName", response.body().getObjReturn().getRequestName());
                edit.commit();
            }

            @Override
            public void onFailure(Call<ResponseObject<ListRequest>> call, Throwable t) {

            }
        });

    }
}
