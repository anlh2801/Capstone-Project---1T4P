package com.odts.apiCaller;

import com.odts.models.ServiceItem;
import com.odts.utils.ResponseObjectReturnList;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface IDeviceApiCaller {
    @GET("/agency/device_in_agency_serviceGroup/{agencyId}/{serviceId}")
    Call<ResponseObjectReturnList<ServiceItem>> getAllDeviceByAgencyIdAndServiceId(@Path("agencyId") int agencyId, @Path("serviceId") int serviceId);
}
