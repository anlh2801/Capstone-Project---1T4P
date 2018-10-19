package com.odts.apiCaller;

import com.odts.models.Request;
import com.odts.utils.ResponseObject;
import com.odts.utils.ResponseObjectReturnList;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface IRequestApiCaller {
    @POST("agency/create_request")
    Call<ResponseObject<Boolean>> addUser(@Body Request request);
}
