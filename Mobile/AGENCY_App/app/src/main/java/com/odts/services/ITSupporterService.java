package com.odts.services;

import android.content.Context;
import android.util.Log;

import com.odts.apiCaller.IITSupporterApiCaller;
import com.odts.models.Device;
import com.odts.utils.CallBackData;
import com.odts.utils.ResponseObject;
import com.odts.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ITSupporterService {
    IITSupporterApiCaller iitSupporterApiCaller;

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
