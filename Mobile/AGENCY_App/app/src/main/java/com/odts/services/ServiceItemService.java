package com.odts.services;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.odts.apiCaller.IServiceITSupportApiCaller;
import com.odts.apiCaller.IServiceItemApiCaller;
import com.odts.models.ServiceITSupport;
import com.odts.models.ServiceItem;
import com.odts.utils.CallBackData;
import com.odts.utils.ResponseObjectReturnList;
import com.odts.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ServiceItemService {
    public void getAllServiceItemByServiceId (final Context context, int serviceId, final CallBackData<ArrayList<ServiceItem>> callBackData) {
        IServiceItemApiCaller service = RetrofitInstance.getRetrofitInstance().create(IServiceItemApiCaller.class);

        /** Call the method with parameter in the interface to get the notice data*/
        Call<ResponseObjectReturnList<ServiceItem>> call = service.getAllServiceItemByServiceId(serviceId);

        /**Log the URL called*/
        Log.wtf("URL Called", call.request().url() + "");

        call.enqueue(new Callback<ResponseObjectReturnList<ServiceItem>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<ServiceItem>> call, Response<ResponseObjectReturnList<ServiceItem>> response) {
                if(response.code() == 200 && response.body() != null){
                    if (!response.body().isError()) {
                        callBackData.onSuccess(response.body().getObjList());
                    }
                    else {
                        Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
                    }

                } else {
                    Log.e("MainActivity", "error" );
                }
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<ServiceItem>> call, Throwable t) {
                Toast.makeText(context, "Có lỗi", Toast.LENGTH_SHORT).show();
            }
        });
    }
}