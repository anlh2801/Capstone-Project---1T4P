package com.odts.services;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.odts.apiCaller.IServiceITSupportApiCaller;
import com.odts.models.ServiceITSupport;
import com.odts.utils.CallBackData;
import com.odts.utils.ResponseObjectReturnList;
import com.odts.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ServiceITSupportService {
    public void getAllServiceITSupport(final Context context, int agencyId, final CallBackData<ArrayList<ServiceITSupport>> callBackData) {
        IServiceITSupportApiCaller service = RetrofitInstance.getRetrofitInstance().create(IServiceITSupportApiCaller.class);

        /** Call the method with parameter in the interface to get the notice data*/
        Call<ResponseObjectReturnList<ServiceITSupport>> call = service.getAllServiceITSupport(agencyId);

        /**Log the URL called*/
//        Log.wtf("URL Called", call.request().url() + "");

        call.enqueue(new Callback<ResponseObjectReturnList<ServiceITSupport>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<ServiceITSupport>> call, Response<ResponseObjectReturnList<ServiceITSupport>> response) {
                if (response.code() == 200 && response.body() != null) {
                    if (!response.body().isError()) {
                        callBackData.onSuccess(response.body().getObjList());
                    }
                } else {
                    Log.e("MainActivity", "error");
                }
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<ServiceITSupport>> call, Throwable t) {

            }
        });
    }
}
