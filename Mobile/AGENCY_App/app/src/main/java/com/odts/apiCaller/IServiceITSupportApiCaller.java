package com.odts.apiCaller;

import com.odts.models.ServiceITSupport;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface IServiceITSupportApiCaller {
    @GET("/agency/serviceITSupport/{agencyId}")
    Call<ServiceITSupport> getAllServiceITSupport(@Path("agencyId") int agencyId);
}
