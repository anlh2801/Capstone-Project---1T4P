package com.odts.it_supporter_app.apiCaller;

import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.utils.ResponseObject;

import retrofit2.Call;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface IITSupporterApiCaller {
    @PUT("request/accept_request/{itSupporterId}/{requestId}/{isAccept}")
    Call<ResponseObject<Boolean>> acceptRequest(@Path("itSupporterId") int itSupporterId,
                                             @Path("requestId") int requestId,
                                             @Path("isAccept") boolean isAccept);

    @POST("ITsupporter/update_status_it ")
    Call<ResponseObject<Boolean>> updateStatusIt(@Query("itsupporter_id") int itsupporter_id,
                                                 @Query("isOnline") boolean isOnline);
}
