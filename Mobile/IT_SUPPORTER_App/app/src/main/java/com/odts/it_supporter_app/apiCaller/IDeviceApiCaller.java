package com.odts.it_supporter_app.apiCaller;

import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.ResponseObjectReturnList;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface IDeviceApiCaller {
    @GET("/agency/device_in_agency_serviceGroup/{agencyId}/{serviceId}")
    Call<ResponseObjectReturnList<Device>> getAllDeviceByAgencyIdAndServiceId(@Path("agencyId") int agencyId, @Path("serviceId") int serviceId);
    @POST("request/add_device_for_request")
    Call<ResponseObject<Boolean>> addDeviceForRequest(@Query("requestId") int requestId, @Body List<Integer> deviceIds);
}
