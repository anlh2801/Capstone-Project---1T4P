package com.odts.apiCaller;

import com.odts.models.Agency;
import com.odts.models.Device;
import com.odts.models.Request;
import com.odts.utils.ResponseObject;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Query;

public interface IAgencyApiCaller {
    @GET("agency/view_profile_agency")
    Call<ResponseObject<Agency>> getAgencyProfile(@Query("agency_id") Integer agency_id);
    @POST("agency/create_device")
    Call<ResponseObject<Boolean>> createDevice(@Body Device device);
    @PUT("agency/update_device")
    Call<ResponseObject<Boolean>> updateDevice(@Body Device device);
}
