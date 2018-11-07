package com.odts.apiCaller;

import com.odts.models.AgencyStatistical;
import com.odts.models.ServiceITSupport;
import com.odts.models.ServiceItem;
import com.odts.utils.ResponseObjectReturnList;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface IServiceItemApiCaller {
    @GET("/agency/serviceItem/{serviceId}")
    Call<ResponseObjectReturnList<ServiceItem>> getAllServiceItemByServiceId(@Path("serviceId") int serviceId);

    @GET("/agency/dashboard/{agencyId}")
    Call<ResponseObjectReturnList<AgencyStatistical>> getAgencyStatistic(@Path("agencyId") int agencyId);
}
