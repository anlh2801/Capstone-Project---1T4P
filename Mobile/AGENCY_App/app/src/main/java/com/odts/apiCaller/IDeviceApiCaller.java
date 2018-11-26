package com.odts.apiCaller;

import com.odts.models.Device;
import com.odts.models.DeviceType;
import com.odts.utils.ResponseObject;
import com.odts.utils.ResponseObjectReturnList;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface IDeviceApiCaller {
    @GET("/agency/device_in_agency_serviceGroup/{agencyId}/{serviceId}")
    Call<ResponseObjectReturnList<Device>> getAllDeviceByAgencyIdAndServiceId(@Path("agencyId") int agencyId, @Path("serviceId") int serviceId);
    @GET("agency/get_deviceType_by_serviceId")
    Call<ResponseObjectReturnList<DeviceType>> getAllDeviceTypeByServiceId(@Query("serviceId") int serviceId);
}
