package com.odts.it_supporter_app.apiCaller;

import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.utils.ResponseObject;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface IRequestApiCaller {

    @GET("request/request_by_id_and_ITSupporterId/{itSupporterId}")
    Call<ResponseObject<Request>> getRequestByRequestIdAndITSupporterId( @Path("itSupporterId") Integer itSupporterId);

    @POST("ticket/update_status_ticket")
    Call<ResponseObject<Boolean>> updateStatusRequest(@Query("request_id") Integer request_id,
                                                      @Query("status") Integer status);
}
