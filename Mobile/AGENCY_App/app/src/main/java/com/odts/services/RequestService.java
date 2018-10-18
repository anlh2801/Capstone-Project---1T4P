package com.odts.services;

import com.odts.models.Request;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface RequestService {
    @POST("agency/create_request")
    Call<Request> addUser(@Body Request request);
}
