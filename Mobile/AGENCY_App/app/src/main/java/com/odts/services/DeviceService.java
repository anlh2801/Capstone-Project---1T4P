package com.odts.services;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.odts.apiCaller.IDeviceApiCaller;
import com.odts.models.Device;
import com.odts.utils.CallBackData;
import com.odts.utils.ResponseObjectReturnList;
import com.odts.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class DeviceService {
    public void getAllDeviceByAgencyIdAndServiceItem (final Context context, int agencyId, int serviceId, final CallBackData<ArrayList<Device>> callBackData) {
        IDeviceApiCaller service = RetrofitInstance.getRetrofitInstance().create(IDeviceApiCaller.class);

        /** Call the method with parameter in the interface to get the notice data*/
        Call<ResponseObjectReturnList<Device>> call = service.getAllDeviceByAgencyIdAndServiceId(agencyId, serviceId);

        /**Log the URL called*/
        Log.wtf("URL Called", call.request().url() + "");

        call.enqueue(new Callback<ResponseObjectReturnList<Device>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<Device>> call, Response<ResponseObjectReturnList<Device>> response) {
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
            public void onFailure(Call<ResponseObjectReturnList<Device>> call, Throwable t) {
                Toast.makeText(context, "Có lỗi", Toast.LENGTH_SHORT).show();
            }
        });
    }
}
