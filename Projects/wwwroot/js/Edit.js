// Bölüm Ekleme
document.getElementById('saveSectionButton').addEventListener('click', function () {
    const form = document.getElementById('addSectionForm');
    if (form.checkValidity()) {
        // AJAX ile formu gönder
        const formData = new FormData(form);
        fetch('/Admin/Project/AddSection', {
            method: 'POST',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    alert('Bölüm başarıyla eklendi!');
                    form.reset(); // Formu sıfırla
                    $('#addSectionModal').modal('hide'); // Modalı kapat
                    location.reload(); // Sayfayı yenile
                } else {
                    alert('Bölüm eklerken bir hata oluştu.');
                }
            })
            .catch(error => {
                console.error('Hata:', error);
                alert('Bölüm eklerken bir hata oluştu.');
            });
    } else {
        form.classList.add('was-validated');
    }
});
$(document).ready(function () {
    $('.delete-buttonsection').on('click', function () {
        var id = $(this).data('id');
        var $item = $(this).closest('li');

        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu öğeyi silmek istediğinizden emin misiniz?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'Hayır, iptal!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Admin/Project/SectionDelete/' + id,
                    type: 'GET',
                    success: function (response) {
                        Swal.fire(
                            'Silindi!',
                            'Öğe başarıyla silindi.',
                            'success'
                        );
                        $item.remove();
                    },
                    error: function (xhr, status, error) {
                        Swal.fire(
                            'Hata!',
                            'Öğe silinirken bir hata oluştu.',
                            'error'
                        );
                    }
                });
            }
        });
    });
    $('.edit-button').on('click', function () {
        var id = $(this).data('id');
        debugger;
        // Backendden mevcut bilgileri almak için bir GET isteği
        $.ajax({
            url: '/Admin/Project/GetSection/' + id,
            type: 'GET',
            success: function (data) {
                debugger;
                // Modal alanlarını doldur
                $('#sectionId1').val(data.id);
                $('#sectionName1').val(data.name);
                $('#sectionDesc1').val(data.desc);
                $('#projectNewId1').val(data.projectNewId);
                $('#sectionOrder1').val(data.orderNumber);
                // Modalı göster
                $('#editModal').modal('show');
            },
            error: function (xhr, status, error) {
                Swal.fire(
                    'Hata!',
                    'Bilgiler getirilirken bir hata oluştu.',
                    'error'
                );
            }
        });
    });
    $('.edit-detail-button').on('click', function () {
        var id = $(this).data('id');
        debugger;
        // Backendden mevcut bilgileri almak için bir GET isteği
        $.ajax({
            url: '/Admin/Project/GetDetailSection/' + id,
            type: 'GET',
            success: function (data) {
                debugger;
                // Modal alanlarını doldur
                $('#sectionIdDetail').val(data.id);
                $('#DetailsectionId').val(data.sectionId);
                $('#sectionDetailName').val(data.name);
                $('#sectionDetailDesc').val(data.desc);
                $('#sectionDetailOrder').val(data.orderNumber);
                // Modalı göster
                $('#editDetailModal').modal('show');
            },
            error: function (xhr, status, error) {
                Swal.fire(
                    'Hata!',
                    'Bilgiler getirilirken bir hata oluştu.',
                    'error'
                );
            }
        });
    });
    $('#editFormDetail').on('submit', function (e) {
        e.preventDefault();

        $.ajax({
            url: '/Admin/Project/UpdateSectionDetail',
            type: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    Swal.fire(
                        'Güncellendi!',
                        'Öğe başarıyla güncellendi.',
                        'success'
                    ).then(() => {
                        // Sayfayı yenile
                        location.reload();
                    });
                } else {
                    Swal.fire(
                        'Hata!',
                        'Öğe güncellenirken bir hata oluştu.',
                        'error'
                    );
                }
            },
            error: function (xhr, status, error) {
                Swal.fire(
                    'Hata!',
                    'İstek yapılırken bir hata oluştu.',
                    'error'
                );
            }
        });
    });
    // Form submit handler
    $('#editForm').on('submit', function (e) {
        e.preventDefault();

        $.ajax({
            url: '/Admin/Project/UpdateSection',
            type: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    Swal.fire(
                        'Güncellendi!',
                        'Öğe başarıyla güncellendi.',
                        'success'
                    ).then(() => {
                        // Sayfayı yenile
                        location.reload();
                    });
                } else {
                    Swal.fire(
                        'Hata!',
                        'Öğe güncellenirken bir hata oluştu.',
                        'error'
                    );
                }
            },
            error: function (xhr, status, error) {
                Swal.fire(
                    'Hata!',
                    'İstek yapılırken bir hata oluştu.',
                    'error'
                );
            }
        });
    });
});
$(document).ready(function () {
    $('.delete-detail-button').on('click', function () {
        const detailId = $(this).data('id');
        Swal.fire({
            title: 'Emin misiniz?',
            text: 'Bu işlem geri alınamaz!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'Hayır, iptal!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/admin/project/deletesectiondetail/${detailId}`,
                    method: 'GET',
                    headers: {
                        'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
                    },
                    success: function (data) {
                        if (data.success) {
                            Swal.fire({
                                icon: 'success',
                                title: 'Silindi!',
                                text: 'Detay başarıyla silindi.',
                                showConfirmButton: false,
                                timer: 1500
                            }).then(() => {
                                location.reload(); // Sayfayı yeniden yükler
                            });
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Hata!',
                                text: 'Detay silinirken bir hata oluştu.'
                            });
                        }
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Hata!',
                            text: 'Sunucuyla iletişim kurarken bir hata oluştu.'
                        });
                    }
                });
            }
        });
    });
    // Add detail button click event
    $('.add-detail-button').on('click', function () {
        const sectionId = $(this).data('id');
        $('#sectionId').val(sectionId);
    });

    // Form submit event
    $('#addDetailForm').on('submit', function (event) {
        event.preventDefault();
        const formData = new FormData(this);

        $.ajax({
            url: '/admin/project/addsectiondetail',
            method: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            headers: {
                'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
            },
            success: function (data) {
                if (data.success) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Başarılı!',
                        text: 'Detay başarıyla eklendi.',
                        showConfirmButton: false,
                        timer: 1500
                    }).then(() => {
                        $('#addDetailModal').modal('hide');
                        location.reload(); // Sayfayı yeniden yükler
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Hata!',
                        text: 'Detay eklenirken bir hata oluştu.'
                    });
                }
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Hata!',
                    text: 'Sunucuyla iletişim kurarken bir hata oluştu.'
                });
            }
        });
    });
});
