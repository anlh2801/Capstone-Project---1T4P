package com.odts.it_supporter_app.apiCaller;

import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.models.ITSupporterStatistic;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.models.RequestGroupMonth;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.ResponseObjectReturnList;

import java.time.LocalDateTime;
import java.util.Date;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface IITSupporterApiCaller {
    @PUT("request/accept_request/{itSupporterId}/{requestId}/{isAccept}/{des}")
    Call<ResponseObject<Boolean>> acceptRequest(@Path("itSupporterId") int itSupporterId,
                                             @Path("requestId") int requestId,
                                             @Path("isAccept") boolean isAccept,
                                                @Path("des") String des);

    @POST("ITsupporter/update_status_it")
    Call<ResponseObject<Boolean>> updateStatusIt(@Query("itsupporter_id") int itsupporter_id,
                                                 @Query("isOnline") boolean isOnline);
    @PUT("ITsupporter/update_Is_Busy_False")
    Call<ResponseObject<Boolean>> updateBusyIt(@Query("itsupporter_id") int itsupporter_id);

    @POST("/ITsupporter/update_starttime")
    Call<ResponseObject<Boolean>> updateStartTime(@Query("request_id") int request_id,
                                                  @Query("start_time") String start_time);
    @POST("/ITsupporter/update_endtime")
    Call<ResponseObject<Boolean>> updateEndTime(@Query("request_id") int request_id,
                                                  @Query("end_time") String start_time);

    @GET("ITsupporter/get_Is_Online")
    Call<ResponseObject<Boolean>> getIsOnline(@Query("itsupporter_id") int itsupporter_id);

    @GET("ITsupporter/get_Is_Busy")
    Call<ResponseObject<Boolean>> getIsBusy(@Query("itsupporter_id") int itsupporter_id);

    @GET("ITsupporter/view_profile_ITsupporter")
    Call<ResponseObject<ITSupporter>> viewProfile(@Query("itsupporter_id") int itsupporter_id);

    @GET("ITsupporter/view_itsupporter_statistic_all")
    Call<ResponseObject<ITSupporterStatistic>> viewITsupporterStatistic(@Query("itsupporterId") int itsupporterId);

    @GET("ITsupporter/view_itsupporter_statistic_today")
    Call<ResponseObject<ITSupporterStatistic>> viewITsupporterStatisticToday(@Query("itsupporterId") int itsupporterId);

    @GET("ITsupporter/view_all_feedback")
    Call<ResponseObjectReturnList<RequestGroupMonth>> viewAllFeedback(@Query("itsupporter_id") int itsupporter_id);

    @GET("ITsupporter/check_device_info_by_code")
    Call<ResponseObject<Device>> checkDeviceInfo(@Query("devcieCode") String devcieCode);
}
