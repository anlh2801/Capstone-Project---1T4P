package com.odts.it_supporter_app.services;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.odts.it_supporter_app.apiCaller.IDeviceApiCaller;
import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.ResponseObjectReturnList;
import com.odts.it_supporter_app.utils.RetrofitInstance;
import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class DeviceService {
    public void getAllDeviceByAgencyIdAndServiceItem(final Context context, int agencyId, int serviceId, final CallBackData<ArrayList<Device>> callBackData) {
        IDeviceApiCaller service = RetrofitInstance.getRetrofitInstance().create(IDeviceApiCaller.class);

        /** Call the method with parameter in the interface to get the notice data*/
        Call<ResponseObjectReturnList<Device>> call = service.getAllDeviceByAgencyIdAndServiceId(agencyId, serviceId);

        /**Log the URL called*/
//        Log.wtf("URL Called", call.request().url() + "");

        call.enqueue(new Callback<ResponseObjectReturnList<Device>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<Device>> call, Response<ResponseObjectReturnList<Device>> response) {
                if (response.code() == 200 && response.body() != null) {
                    if (!response.body().isError()) {
                        callBackData.onSuccess(response.body().getObjList());
                    }

                } else {
                    Log.e("MainActivity", "error");
                }
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<Device>> call, Throwable t) {
            }
        });
    }
    public void addDeviceForRequest(final  Context context,int requestId,  List<Integer> deviceIds, final CallBackData<Boolean> callBackData) {
        IDeviceApiCaller service = RetrofitInstance.getRetrofitInstance().create(IDeviceApiCaller.class);

        /** Call the method with parameter in the interface to get the notice data*/
        Call<ResponseObject<Boolean>> call = service.addDeviceForRequest(requestId, deviceIds);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                if(response.code() == 200 && response.body() != null) {
                    if(!response.body().isError()) {
                        Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    }
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {

            }
        });
    }
}
