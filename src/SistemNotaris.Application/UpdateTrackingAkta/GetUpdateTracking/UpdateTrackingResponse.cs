        namespace SistemNotaris.Application.UpdateTrackingAkta.GetUpdateTracking;

        public class UpdateTrackingResponse
        {
            public required string NamaKaryawan { get; init; }
            public required string DeskripsiPengerjaan { get; init; }
            public required DateTime CreatedAt { get; init; }
        }