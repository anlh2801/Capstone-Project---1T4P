package com.odts.it_supporter_app.apiCaller;

import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.utils.ResponseObject;

import retrofit2.Call;
import retrofit2.http.POST;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface IITSupporterApiCaller {
    @POST("request/accept_request/{itSupporterId}/{requestId}/{isAccept}")
    Call<ResponseObject<Boolean>> acceptRequest(@Path("itSupporterId") int itSupporterId,
                                             @Path("requestId") int requestId,
                                             @Path("isAccept") boolean isAccept);
}