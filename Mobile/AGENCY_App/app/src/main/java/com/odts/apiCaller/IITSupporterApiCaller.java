package com.odts.apiCaller;


import com.odts.models.Device;
import com.odts.utils.ResponseObject;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface IITSupporterApiCaller {

    @GET("ITsupporter/check_device_info_by_code")
    Call<ResponseObject<Device>> checkDeviceInfo(@Query("devcieCode") String devcieCode);
}
